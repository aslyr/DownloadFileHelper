using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using AngleSharp.Html.Parser;
using Microsoft.VisualBasic;

namespace ConsoleApp1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            #region xvideos下载
            // var handler=new HttpClientHandler();
            // handler.UseCookies = true;
            // var xvideosRoot = "https://www.xvideos.com/";
            // using var client=new HttpClient(handler);
            // var cookie =
            //     @"wpn_ad_cookie=ad08baf6a1821cfc8c55bad6d4cf30b7; X-Backend=10|X4V9V|X4V9N; chat_data_c=; chat_deco=0; freechvws=343648723; undefined=0; hexavid_static=hw; intr-3959997=1; last_views=%5B%2248768087-1602585625%22%2C%2249167581-1602585678%22%2C%2248605107-1602585695%22%2C%2253941267-1602585713%22%2C%2249138507-1602585729%22%2C%2254787841-1602585742%22%2C%2253739555-1602585756%22%2C%2249496301-1602586057%22%2C%2249305129-1602586076%22%2C%2254903345-1602586089%22%2C%2251217759-1602586109%22%2C%2254357231-1602586125%22%2C%2252040253-1602586138%22%2C%2248794851-1602586159%22%2C%2248627807-1602586173%22%2C%2249116301-1602586189%22%2C%2249668773-1602586219%22%2C%2251900725-1602586241%22%2C%2254766301-1602586269%22%2C%2248070881-1602586282%22%2C%2250107667-1602586300%22%2C%2251395091-1602586314%22%2C%2255992249-1602586331%22%2C%2255971823-1602586344%22%2C%2248499203-1602586355%22%2C%2252895669-1602586370%22%2C%2250061013-1602586382%22%2C%2248479293-1602586400%22%2C%2254179177-1602586413%22%2C%2254719561-1602586430%22%2C%2254060383-1602586448%22%2C%2251039477-1602586475%22%2C%2254432895-1602586497%22%2C%2251901927-1602586514%22%2C%2249827357-1602586534%22%2C%2249138295-1602586550%22%2C%2254178745-1602586570%22%2C%2254903729-1602586590%22%2C%2249351717-1602586602%22%2C%2248453751-1602586628%22%2C%2248288020-1602586639%22%2C%2250061053-1602586656%22%2C%2254766149-1602586675%22%2C%2248374771-1602586689%22%2C%2248794925-1602586741%22%2C%2250107641-1602586758%22%2C%2248478721-1602586773%22%2C%2252040503-1602586799%22%2C%2252367069-1602586810%22%2C%2251040487-1602586824%22%2C%2251785687-1602586858%22%2C%2248985601-1602586872%22%2C%2250155173-1602586884%22%2C%2248627863-1602586906%22%2C%2250419695-1602586920%22%2C%2248208538-1602586937%22%2C%2254041247-1602587004%22%2C%2253940539-1602587018%22%2C%2252895519-1602587040%22%2C%2249305011-1602587051%22%2C%2249764009-1602587061%22%2C%2248459315-1602587075%22%2C%2254335585-1602587089%22%2C%2254276097-1602587101%22%2C%2254413325-1602587113%22%2C%2248308809-1602587129%22%2C%2248072761-1602587139%22%2C%2254412907-1602587157%22%2C%2250419663-1602587167%22%2C%2254719461-1602587178%22%2C%2249081849-1602587190%22%5D; pending_thumb=%7B%22t%22%3A%5B%5D%2C%22s%22%3A%5B%5D%2C%22p%22%3A%5B%5D%2C%22r%22%3A%5B%5D%7D; thumbloadstats_vthumbs=%7B%222%22%3A%5B%7B%22s%22%3A2%2C%22d%22%3A1077%7D%2C%7B%22s%22%3A2%2C%22d%22%3A243%7D%2C%7B%22s%22%3A2%2C%22d%22%3A2968%7D%5D%2C%223%22%3A%5B%7B%22s%22%3A2%2C%22d%22%3A702%7D%2C%7B%22s%22%3A2%2C%22d%22%3A194%7D%2C%7B%22s%22%3A2%2C%22d%22%3A2110%7D%5D%2C%2210%22%3A%5B%7B%22s%22%3A2%2C%22d%22%3A933%7D%2C%7B%22s%22%3A2%2C%22d%22%3A128%7D%2C%7B%22s%22%3A2%2C%22d%22%3A1469%7D%5D%2C%22last%22%3A%7B%22s%22%3A2%2C%22v%22%3A%5B2968%2C2110%2C1469%5D%7D%7D; session_token=308b1f3323a02bc467Fp_hENIgphMMYJz2IISPldugeVRTsCiHStv06p5cQQimRYg0BowP9jV8yMiyL7NbR1ClhpSxo_TQb6Wm1u1EPFWYNrvj2Y991gza79GS0YX_4Y9kudBb5buoByJ9_tzg1cGSGasCJi7IOFYQXI29hR1Y-T48TzH-t8caWI0Jp70Raetgi0qbRrvkUPnZWHsSTa7dQ6kwXp8pZmb5pNcR93pNopYyiMHlM_mVw_b5vxItscwGr4TZbmWV40xbj8atkZ5mRo3HWtXB8TIOrAby6Xig0RnlOXO_3HOxeAoa5M0Xb5zQ0kKJd3O1GcD01osh_iqgjSxkrTBKFYM3JKWDr2axMWvRx5mPi035k2wHowyp8h8c7y4qN0G7dWj_PHRRPb9Myg-nS9OYY3F6coxGHMKemwwkq9vH8LB1BH17yvyVlbDK1mT9lH9U9m5VPVaE4OWCKZLwAx_Ao-LY5j348vvuoDCuq5rSXSZltw3-A%3D";
            // client.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/64.0.3282.140 Safari/537.36 Edge/17.17134");
            // client.DefaultRequestHeaders.Add("Cookie",cookie);
            // List<KeyValuePair<string, string>> PostList = new List<KeyValuePair<string, string>>()
            // {
            //     new KeyValuePair<string, string>("main_cats", "false")
            // };
            // var message=await client.PostAsync("https://www.xvideos.com/channels/jukujosukidesu/videos/best/6",new FormUrlEncodedContent(PostList));
            // var html2 =await message.Content.ReadAsStringAsync();
            // var parser=new HtmlParser();
            // var doc = parser.ParseDocument(html2);
            // var content = doc.QuerySelectorAll(".mozaique .thumb-under");
            // var length = 0;
            // foreach (var item in content)
            // {
            //    var duration=  item.QuerySelector(".duration");
            //    if (!duration.TextContent.Contains("min"))
            //    {  length++;
            //       var alink=  item.QuerySelector(".title a");
            //       var page=alink.Attributes["href"].Value;
            //       var PageUrl = xvideosRoot + page;
            //       var mp4name=alink.Attributes["title"].Value;
            //       var html = await client.GetStringAsync(PageUrl);
            //       var mp4url = Regex.Match(html, @"html5player.setVideoUrlHigh\('(.*?)'\)").Groups[1].Value;
            //       await  DownloadFile(mp4url);
            //       Console.WriteLine($"第{length}个下载完成");
            //    };
            // }
            #endregion

            Console.WriteLine("你好");
            await DownloadFile("http://8dx.pc6.com/xzx6/Postmanwin64_v7.24.0.exe", chunk: 1024 * 1024*10,referrer: "http://www.pc6.com/softview/SoftView_423615.html");
           


        }
        /// <summary>
        /// 多线程下载文件
        /// </summary>
        /// <param name="url">下载文件地址</param>
        /// <param name="chunk">最小下载单位，单位为bit，1024*1024为1kb</param>
        /// <param name="path">保存路径</param>
        /// <param name="httpClient">默认使用的httpClient</param>
        /// <returns></returns>
        static async Task DownloadFile(string url,int chunk=1024*1024,string? path=null,string? referrer="",HttpClient? httpClient=null)
        {
            if (httpClient==null)
            { httpClient=new HttpClient();
                httpClient.DefaultRequestHeaders.Referrer =new Uri(referrer);
            }
            //
           
            long start = 0;
            
            int pos = 0;
            long max = 0;
            bool canMult = false;
            CancellationToken cancelTok;
            //异步获取响应头，不获取content
            var res= await  httpClient.GetAsync(url,HttpCompletionOption.ResponseHeadersRead,cancelTok);
            Console.WriteLine(res.StatusCode);
            if (path==null)
            {
                Console.WriteLine(url?.LastIndexOf("/"));
                //获取下载文件的文件吗
                path = url?.Substring((url?.LastIndexOf("/")?? 0)+1);
                Console.WriteLine($"path 的值 为{path}");
            }
            //获取总文件大小
            max = res.Content.Headers.ContentLength ?? 0;
            if (res.Headers.AcceptRanges.Count>0)
            {
                canMult = true;
                
            }

            if (!canMult || max<=chunk)
            {
                var fs = File.Open(path, FileMode.Create);
                var stream = await res.Content.ReadAsStreamAsync();
                
                await stream.CopyToAsync(fs);
                fs.Close();
            }

            if (canMult  )
            {  
              
               
               var partnum = Math.Ceiling( (double)max / (double)chunk);
               Console.WriteLine($"共分了{partnum}段，一共有{max}字节");
               Stopwatch st1=new Stopwatch();
               var t1 = DateTime.Now;
               st1.Start();
               List<Task> tasks=new List<Task>();
               for (long j = 0; j < partnum; j++)
               {
                   
                       var i=j;
                       
                       var task = Task.Run( () =>
                       {
                           var now = chunk * (i + 1);
                           if (now >= max)
                           {
                               now = max;
                               
                           }

                           using var fs = File.Open(path, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write);
                           using var http = new HttpClient();
                           http.DefaultRequestHeaders.Referrer=new Uri(referrer);
                           http.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/78.0.3904.108 Safari/537.36");
                           http.DefaultRequestHeaders.Add("Range", $"bytes={start+chunk*i}-{now}");
                           Console.WriteLine($"offset 为{start + chunk * i}");
                           Console.WriteLine($"now 为{now}");
                           Console.WriteLine($"正在下载，请稍等。。。。进度百分之{(float)(start + chunk * i) / max:P}");
                           var bytes =  http.GetByteArrayAsync(url).Result;
                           fs.Seek(start+chunk*i, SeekOrigin.Begin);
                           fs.Write(bytes);
                           fs.Close();
                           Console.WriteLine($"下载完成。。。。进度百分之{(float)(start + chunk * i) / max:P}");
                           
                       });
                       tasks.Add(task);
               }
               
               Task.WaitAll(tasks.ToArray());
               st1.Stop();
               var t2 = DateTime.Now;
               if (st1.Elapsed.Seconds!=0)
               {
                   Console.WriteLine($"下载完毕！多线程用时{st1.Elapsed.Seconds}秒,平均每秒下载{max/1024/1024/st1.Elapsed.Seconds}MBs");
                   Console.WriteLine($"下载完毕！多线程用时{(t2-t1).Seconds}秒,平均每秒下载{max/1024/1024/(t2-t1).Seconds}MBs");
               }
            
            }

        }
    }
   
}