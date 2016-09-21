using Lucene.Net.Analysis;
using Lucene.Net.Analysis.PanGu;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.Search;
using Lucene.Net.Store;
using PanGu;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunXiu.Commom
{
    public class LuceneNet
    {
        private object IndexLock = new object();
        public LuceneNet() { }

        public LuceneNet(string indexPath)
        {
            IndexPath = indexPath;
        }
        /// <summary>
        /// 索引库路径
        /// </summary>
        public string IndexPath { get; set; }

        /// <summary>
        /// 创建集合索引
        /// </summary>
        /// <typeparam name="T">集合</typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool CreateIndexByData<T>(List<T> list, Dictionary<string, bool> createIndexField, bool isDeleteIndex)
        {
            var result = false;
            try
            {
                if (isDeleteIndex)
                {
                    System.IO.Directory.Delete(IndexPath, true);
                }

                FSDirectory directory = null;
                IndexWriter writer = GetIndexWriter(out directory);
                CreateIndexDocument(list, createIndexField, writer);
                writer.Close();
                directory.Close();
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }

        /// <summary>
        /// 删除索引库的文档
        /// </summary>
        /// <param name="field">字段名</param>
        /// <param name="val">字段值</param>
        /// <returns></returns>
        public bool DeleteDocument(string field, string val)
        {
            var result = false;
            try
            {
                lock (IndexLock)
                {
                    FSDirectory directory = null;
                    IndexWriter writer = GetIndexWriter(out directory);
                    writer.DeleteDocuments(new Term(field, val));
                    result = true;
                    writer.Close();
                    directory.Close();
                }
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }

        /// <summary>
        /// 修改文档
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="field">文档ID</param>
        /// <returns></returns>
        public bool UpdateDocument<T>(T t, string field, Dictionary<string, bool> createIndexField)
        {
            var result = false;
            try
            {
                Type type = typeof(T);
                var o = type.GetProperty(field);
                var fieldVal = Convert.ToString(o.GetValue(t));//字段值
                if (DeleteDocument(field, fieldVal))//先删再添加
                {
                    result = CreateIndexByData<T>(new List<T> { t }, createIndexField, false);
                }
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        /// <summary>
        /// 根据关键字搜索文档
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="searchKey"></param>
        /// <param name="needSearchField"></param>
        /// <returns></returns>
        public List<T> SearchFromIndexData<T>(string searchKey, int pageIndex, int pageSize, out int totalCount, string needSearchField)
        {
            List<T> list = new List<T>();
            FSDirectory directory = FSDirectory.Open(new DirectoryInfo(IndexPath), new NoLockFactory());
            IndexReader reader = IndexReader.Open(directory, true);
            IndexSearcher searcher = new IndexSearcher(reader);
            //搜索条件
            PhraseQuery query = new PhraseQuery();
            //把用户输入的关键字进行分词
            foreach (string word in SplitWords(searchKey))
            {
                query.Add(new Term(needSearchField, word));
            }
            //query.Add(new Term("content", "C#"));//多个查询条件时 为且的关系
            query.SetSlop(100); //指定关键词相隔最大距离

            //TopScoreDocCollector盛放查询结果的容器
            TopScoreDocCollector collector = TopScoreDocCollector.create(1000, true);
            Sort sort = new Sort(new SortField("PID", SortField.DOC, false));
            var docResult = searcher.Search(query, sort);//根据query查询条件进行查询，查询结果放入collector容器
                                                         //TopDocs 指定0到GetTotalHits() 即所有查询结果中的文档 如果TopDocs(20,10)则意味着获取第20-30之间文档内容 达到分页的效果

            //  ScoreDoc[] docs = collector.TopDocs(0, collector.GetTotalHits()).scoreDocs;
            totalCount = docResult.Length();
            int startIndex = Math.Max((pageIndex - 1) * pageSize, 0);
            int endIndex = 0;
            if (totalCount < pageSize)
            {
                endIndex = startIndex + totalCount;
            }
            else
            {
                endIndex = startIndex + pageSize;
            }

            //展示数据实体对象集合
            for (int i = startIndex; i < endIndex; i++)
            {
                int docId = docResult.Id(i);//得到查询结果文档的id（Lucene内部分配的id）
                Document doc = searcher.Doc(docId);//根据文档id来获得文档对象Document

                T t = Activator.CreateInstance<T>();//创建T对象
                Type type = typeof(T);
                var fieldList = type.GetProperties();
                for (int j = 0; j < fieldList.Length; j++)
                {
                    var f = type.GetProperty(fieldList[j].Name);
                    f.SetValue(t, Utilities.ConvertToT(f.PropertyType.Name, doc.Get(fieldList[j].Name)));
                }
                list.Add(t);
            }
            return list;
        }

        public List<T> SearchFromIndexData<T>(string searchKey, int pageIndex, int pageSize, out int totalCount, string orderByFiled, bool isDesc, string needSearchField)
        {
            List<T> list = new List<T>();
            FSDirectory directory = FSDirectory.Open(new DirectoryInfo(IndexPath), new NoLockFactory());
            IndexReader reader = IndexReader.Open(directory, true);
            IndexSearcher searcher = new IndexSearcher(reader);
            //搜索条件
            PhraseQuery query = new PhraseQuery();
            //把用户输入的关键字进行分词
            foreach (string word in SplitWords(searchKey))
            {
                query.Add(new Term(needSearchField, word));
            }
            //query.Add(new Term("content", "C#"));//多个查询条件时 为且的关系
            query.SetSlop(100); //指定关键词相隔最大距离

            //TopScoreDocCollector盛放查询结果的容器
            TopScoreDocCollector collector = TopScoreDocCollector.create(1000, true);
            Sort sort = new Sort(new SortField(orderByFiled, SortField.DOC, isDesc));
            var docResult = searcher.Search(query, sort);//根据query查询条件进行查询，查询结果放入collector容器
                                                         //TopDocs 指定0到GetTotalHits() 即所有查询结果中的文档 如果TopDocs(20,10)则意味着获取第20-30之间文档内容 达到分页的效果

            //  ScoreDoc[] docs = collector.TopDocs(0, collector.GetTotalHits()).scoreDocs;
            totalCount = docResult.Length();
            int startIndex = Math.Max((pageIndex - 1) * pageSize, 0);
            int endIndex = 0;
            if (totalCount < pageSize)
            {
                endIndex = startIndex + totalCount;
            }
            else
            {
                endIndex = startIndex + pageSize;
            }

            //展示数据实体对象集合
            for (int i = startIndex; i < endIndex; i++)
            {
                int docId = docResult.Id(i);//得到查询结果文档的id（Lucene内部分配的id）
                Document doc = searcher.Doc(docId);//根据文档id来获得文档对象Document

                T t = Activator.CreateInstance<T>();//创建T对象
                Type type = typeof(T);
                var fieldList = type.GetProperties();
                for (int j = 0; j < fieldList.Length; j++)
                {
                    var f = type.GetProperty(fieldList[j].Name);
                    f.SetValue(t, Utilities.ConvertToT(f.PropertyType.Name, doc.Get(fieldList[j].Name)));
                }
                list.Add(t);
            }
            return list;
        }

        private string[] SplitWords(string content)
        {
            List<string> strList = new List<string>();
            Analyzer analyzer = new PanGuAnalyzer();//指定使用盘古 PanGuAnalyzer 分词算法
            TokenStream tokenStream = analyzer.TokenStream("", new StringReader(content));
            Lucene.Net.Analysis.Token token = null;
            while ((token = tokenStream.Next()) != null)
            { //Next继续分词 直至返回null
                strList.Add(token.TermText()); //得到分词后结果
            }
            return strList.ToArray();
        }

        /// <summary>
        /// 关键字高亮 
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        private string HightLight(string keyword, string content)
        {
            //创建HTMLFormatter,参数为高亮单词的前后缀
            PanGu.HighLight.SimpleHTMLFormatter simpleHTMLFormatter =
                new PanGu.HighLight.SimpleHTMLFormatter("<font style=\"font-style:normal;color:#cc0000;\"><b>", "</b></font>");
            //创建 Highlighter ，输入HTMLFormatter 和 盘古分词对象Semgent
            PanGu.HighLight.Highlighter highlighter =
                            new PanGu.HighLight.Highlighter(simpleHTMLFormatter,
                            new Segment());
            //设置每个摘要段的字符数
            highlighter.FragmentSize = 1000;
            //获取最匹配的摘要段
            return highlighter.GetBestFragment(keyword, content);
        }

        /// <summary>
        /// 获取索引文档
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="needCreateIndexField"></param>
        /// <returns></returns>
        private void CreateIndexDocument<T>(List<T> list, Dictionary<string, bool> createIndexField, IndexWriter write)
        {
            try
            {
                lock (IndexLock)
                {
                    Type type = typeof(T);
                    for (int i = 0; i < list.Count; i++)
                    {
                        var doc = new Document();
                        foreach (var key in createIndexField.Keys)
                        {
                            var field = key;//字段
                            var isCreateIndex = createIndexField[field];
                            var o = type.GetProperty(field);
                            var fieldVal = Convert.ToString(o.GetValue(list[i]));//字段值

                            if (!isCreateIndex)//该字段是否需要创建索引 
                            {
                                doc.Add(new Field(field, fieldVal, Field.Store.YES, Field.Index.NOT_ANALYZED));//--所有字段的值都将以字符串类型保存 因为索引库只存储字符串类型数据
                            }
                            else
                            {
                                doc.Add(new Field(field, fieldVal, Field.Store.YES, Field.Index.ANALYZED, Field.TermVector.WITH_POSITIONS_OFFSETS));
                            }
                        }
                        write.AddDocument(doc);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private IndexWriter GetIndexWriter(out FSDirectory directory)
        {
            IndexWriter writer = null;
            directory = null;
            try
            {
                directory = FSDirectory.Open(new DirectoryInfo(IndexPath), new NativeFSLockFactory());
                bool isExist = IndexReader.IndexExists(directory);
                if (isExist)
                {
                    if (IndexWriter.IsLocked(directory))
                    {
                        IndexWriter.Unlock(directory);
                    }
                }
                writer = new IndexWriter(directory, new PanGuAnalyzer(), !isExist, IndexWriter.MaxFieldLength.UNLIMITED);
            }
            catch (Exception ex)
            {

            }
            return writer;
        }
    }
}
