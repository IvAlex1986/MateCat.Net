using MateCat.Net.Attributes;
using MateCat.Net.Enums;
using MateCat.Net.Helpers;
using MateCat.Net.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;

namespace MateCat.Net
{
    public class MateCatApi : IMateCatApi
    {
        private const String DefaultBaseUrl = "https://www.matecat.com/api/";

        public MateCatApi()
        {
            BaseUrl = DefaultBaseUrl;
        }

        public MateCatApi(String baseUrl)
            : this()
        {
            BaseUrl = baseUrl;
        }

        #region IMateCatApi

        public String BaseUrl { get; set; }

        public Project CreateProject(
            IEnumerable<ProjectFile> files,
            String projectName,
            String sourceLanguage,
            String targetLanguage,
            String subject,
            Boolean useMemoryServer = true,
            Boolean useMachineTranslation = true,
            String privateKey = "",
            SegmentationRule segmantationRule = SegmentationRule.General)
        {
            var url = String.Concat(BaseUrl, "new");

            var httpFiles = files.Select(n => new HttpPostFile
                {
                    Name = Path.GetFileNameWithoutExtension(n.FileName),
                    FileName = n.FileName,
                    Stream = n.Stream
                })
                .ToList();


            var parameters = new NameValueCollection
            {
                { "project_name", projectName },
                { "source_lang", sourceLanguage },
                { "target_lang", targetLanguage },
                { "tms_engine", BooleanToIntegerString(useMemoryServer) },
                { "mt_engine", BooleanToIntegerString(useMachineTranslation) },
                { "private_tm_key", privateKey },
                { "subject", subject },
                { "segmentation_rule", segmantationRule.GetAttribute<CodeAttribute>().Value }
            };

            var response = HttpHelper.UploadFiles(url, httpFiles, parameters);

            return DesirializeResponse<Project>(response);
        }

        public Project ChangeProjectPassword(Int32 id, String oldPassword, String newPassword)
        {
            var url = String.Concat(BaseUrl, "change_project_password");

            var parameters = new NameValueCollection
            {
                { "id_project", id.ToString() },
                { "old_pass", oldPassword },
                { "new_pass", newPassword }
            };

            var response = HttpHelper.Post(url, parameters);

            return DesirializeResponse<Project>(response);
        }

        public Project CreateProject(
            IEnumerable<ProjectFile> files,
            String projectName,
            String sourceLanguage,
            String targetLanguage,
            SupportedSubject subject = SupportedSubject.General,
            Boolean useMemoryServer = true,
            Boolean useMachineTranslation = true,
            String privateKey = "",
            SegmentationRule segmantationRule = SegmentationRule.General)
        {
            return CreateProject(
                files,
                projectName,
                sourceLanguage,
                targetLanguage,
                subject.GetAttribute<CodeAttribute>().Value,
                useMemoryServer,
                useMachineTranslation,
                privateKey,
                segmantationRule);
        }

        public String GetProjectStatusString(Int32 id, String password)
        {
            var url = String.Format("{0}status/?id_project={1}&project_pass={2}", BaseUrl, id, password);

            var response = HttpHelper.Get(url);

            return response;
        }

        public ProjectStatus GetProjectStatus(Int32 id, String password)
        {
            var value = GetProjectStatusString(id, password);
            return DesirializeResponse<ProjectStatus>(value);
        }

        #endregion IMateCatApi

        #region Private

        private static T DesirializeResponse<T>(String response) where T : class
        {
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(response));

            var settings = new DataContractJsonSerializerSettings
            {
                UseSimpleDictionaryFormat = true
            };

            var serializer = new DataContractJsonSerializer(typeof(T), settings);

            return (T)serializer.ReadObject(stream);
        }

        private static String BooleanToIntegerString(Boolean value)
        {
            return Convert.ToInt32(value).ToString();
        }

        #endregion Private
    }
}
