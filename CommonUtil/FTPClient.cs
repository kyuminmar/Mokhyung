﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CommonUtil
{
    public class FTPClient
    {

        public FTPClient()
        {
            string _serverIP = "kyuminmar.ipdisk.co.kr";
            string _id = "kyuminmar";
            string _password = "rbalsdl1!";
        }

        /// <summary>
        /// 파일 업로드
        /// </summary>
        /// <param name="LocalFilePath"></param>
        /// <param name="FtpfilePath"></param>
        //public void UpLoad(string LocalFilePath,string FtpfilePath)
        //{
        //    //FTP다운로드관련 URL, Method설정(UploadFile)
        //    string uri = FtpfilePath;

        //    FtpWebRequest request = (FtpWebRequest)WebRequest.Create(uri);
        //    request.Method = WebRequestMethods.Ftp.UploadFile;
        //    request.Credentials = new NetworkCredential("kyuminmar","rbalsdl1!");





        //    //파일정보를 Byte로열기
        //    byte[] fileContents = null;
        //    //using (BinaryReader br = new BinaryReader(File.Open(LocalFilePath, FileMode.Open)))
        //    using (BinaryReader br = new BinaryReader(File.Open(LocalFilePath, FileMode.Open)))
        //    {
        //        //EPS파일을 변수로 선언
        //        var converter = new GroupDocs.Conversion.Converter(LocalFilePath);
        //        // Set conversion parameters for PDF format

        //        //PDF로 변환기 설정
        //        var convertOptions = converter.GetPossibleConversions()["pdf"].ConvertOptions;
        //        // PDF로 변환
        //        converter.Convert(FtpfilePath, convertOptions);

        //        long dataLength = br.BaseStream.Length;
        //        fileContents = new byte[br.BaseStream.Length];
        //        fileContents = br.ReadBytes((int)br.BaseStream.Length);
        //    }

        //    //FTP서버에 파일전송처리
        //    request.ContentLength = fileContents.LongLength;
        //    using (Stream requestStream = request.GetRequestStream())
        //    {
        //        requestStream.Write(fileContents, 0, fileContents.Length);


        //    }

        //    //FTP전송결과확인
        //    using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
        //    {
        //        Console.WriteLine($"Upload File Complete, status {response.StatusDescription}");
        //    }
        //}


        /// <summary>
        /// 파일 업로드
        /// </summary>
        /// <param name="LocalFilePath"></param>
        /// <param name="FtpfilePath"></param>
        public void UpLoad(string LocalFilePath, string FtpfilePath)
        {
            // FTP 업로드
            using (var client = new WebClient())
            {

                client.Credentials = new NetworkCredential("kyuminmar", "rbalsdl1!");
                string LFPExtention = (LocalFilePath.Split('.')[LocalFilePath.Split('.').Length - 1]).ToUpper();

                

                //확장자가 EPS일 경우
                if (LFPExtention =="EPS")
                {
                    //EPS파일을 가져옴
                    var converter = new GroupDocs.Conversion.Converter(LocalFilePath);
                    // Set conversion parameters for PDF format
                    var convertOptions = converter.GetPossibleConversions()["pdf"].ConvertOptions;

                    //로컬 경로의 확장자를 pdf로 바꿔줌
                    LocalFilePath = LocalFilePath.Replace(LocalFilePath.Split('.')[LocalFilePath.Split('.').Length - 1], "pdf");
                    // Convert to PDF format
                    converter.Convert(LocalFilePath, convertOptions);
                }
                //ftp로 업로드
                client.UploadFile(FtpfilePath, LocalFilePath);
            }

            //// FTP 다운로드
            //using (var client = new WebClient())
            //{
            //    client.Credentials = new NetworkCredential(user, pwd);
            //    client.DownloadFile("ftp://ftp.dlptest.com/test1.dat", @"C:\Temp\testdn.dat");
            //}
        }





        /// <summary>
        /// 파일다운로드
        /// </summary>
        /// <param name="downloadPath"></param>
        /// <param name="saveFilePath"></param>
        //public void DownLoad(string downloadPath, string saveFilePath)
        //{
        //    //FTP다운로드관련 URL, Method설정(DownloadFile)
        //    string uri = string.Format("ftp://{0}/{1}", _serverIP, downloadPath);
        //    FtpWebRequest request = (FtpWebRequest)WebRequest.Create(uri);
        //    request.Method = WebRequestMethods.Ftp.DownloadFile;
        //    request.Credentials = new NetworkCredential(_id, _password);

        //    //FTP서버에 파일다운로드요청
        //    FtpWebResponse response = (FtpWebResponse)request.GetResponse();
        //    Stream responseStream = response.GetResponseStream();

        //    int fileContentsLength = 4096;
        //    byte[] fileContents = new byte[fileContentsLength];

        //    Stream stream = new FileStream(saveFilePath, FileMode.Create);

        //    //이진데이터로쓰기
        //    using (BinaryWriter bw = new BinaryWriter(stream))
        //    {
        //        using (BinaryReader br = new BinaryReader(responseStream))
        //        {
        //            fileContentsLength = br.Read(fileContents, 0, fileContentsLength);
        //            while (fileContentsLength > 0)
        //            {
        //                fileContentsLength = br.Read(fileContents, 0, fileContentsLength);
        //                bw.Write(fileContents);
        //                fileContents = new byte[fileContentsLength];
        //            }
        //        }

        //    }
        //}

    }
}
