using System;
using System.Net;

namespace GetJSONBYSMS.chuanyuantong.com
{
    class Program
    {

        static void Main(string[] args)
        {
            /*
             https://sms.chuanyuantong.com/chuanyuan/config/?title=contentsConfig
            Host: sms.chuanyuantong.com
            Origin: http://localhost:8080
            Accept-Encoding: gzip, deflate, br
            Connection: keep-alive
            Accept: application/json, text/plain, *//*
            User - Agent: Mozilla / 5.0(iPhone; CPU iPhone OS 15_1 like Mac OS X) AppleWebKit / 605.1.15(KHTML, like Gecko) Mobile / 15E148 / ricjngyniqtgdjkcckssmakslyqiubcf
            Authorization: Token 4ed2d2f56b0e6f9852256b27f3bc32c5e1c42e4b
            Referer: http://localhost:8080/
            Accept - Language: zh - CN,zh - Hans; q = 0.9
            */

            //https://sms.chuanyuantong.com/chuanyuan/questionmodel/?contents=501459&id__in!=&limit=10&offset=0&ordering=id&is_delete=false
            // Host: sms.chuanyuantong.com
            //Origin: http://localhost:8080
            //Accept-Encoding: gzip, deflate, br
            //Connection: keep-alive
            //Accept: application/json, text/plain, */*
            //User - Agent: Mozilla / 5.0(iPhone; CPU iPhone OS 15_1 like Mac OS X) AppleWebKit / 605.1.15(KHTML, like Gecko) Mobile / 15E148 / unrgfgmifjyoaanamloqqxupzizrjfqy
            //Authorization: Token 4ed2d2f56b0e6f9852256b27f3bc32c5e1c42e4b
            string url = "https://sms.chuanyuantong.com/chuanyuan/questionmodel/?contents=501453&id__in!=&limit=10&offset=0&ordering=id&is_delete=false";
            Uri uri = new Uri(url);
            string token = "Token 4ed2d2f56b0e6f9852256b27f3bc32c5e1c42e4b";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = "GET";
            request.UserAgent = "Mozilla / 5.0(iPhone; CPU iPhone OS 15_1 like Mac OS X) AppleWebKit / 605.1.15(KHTML, like Gecko) Mobile / 15E148 / unrgfgmifjyoaanamloqqxupzizrjfqy";
            request.Headers.Add(HttpRequestHeader.Authorization, token);
            request.Accept = "application/json, text/plain, */*";
            request.Host = "sms.chuanyuantong.com";
            request.KeepAlive = true;
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream responsestream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responsestream, System.Text.Encoding.UTF8);
                string StrResponse = reader.ReadToEnd();
                reader.Close();
                response.Close();
                File.AppendAllLines("d://1.txt", new string[] {
                    "\r\n",
                   string.Format( "——————————————{0}——————————————————\r\n",DateTime.Now.ToString())
                });
                File.AppendAllText("d://1.txt", StrResponse + "\r\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString);
            }
            //Console.ReadLine();
        }
    }
}
