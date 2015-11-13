using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace CodeGenerator.Utils
{
    using System.IO;
    using System.Text;


    public static class JsonUtils
    {
        public static string ToJSON(this object obj)
        {
            return ToJSON(obj, null);
        }

        public static string ToJSON(this object obj, int? maxDepth)
        {
            JsonSerializer serializer = new JsonSerializer();

            if (maxDepth.HasValue)
            {
                serializer.MaxDepth = maxDepth;
            }

            StringBuilder sb = new StringBuilder();
            using (StringWriter textWriter = new StringWriter(sb))
            {
                JsonTextWriter writer = new JsonTextWriter(textWriter);
                serializer.Serialize(writer, obj);
                writer.Flush();
            }

            return sb.ToString();
        }

        public static T FromJSON<T>(this string data)
        {
            return FromJSON<T>(data, null);
        }

        public static Stream ToStream(this string data)
        {
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(data);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        public static string ConvertToString(this Stream data)
        {

            using (StreamReader reader = new StreamReader(data, Encoding.UTF8))
            {
                return reader.ReadToEnd();
            }
        }

        public static T FromJSON<T>(this string data, int? maxDepth)
        {
            JsonSerializer serializer = new JsonSerializer();

            if (maxDepth.HasValue)
            {
                serializer.MaxDepth = maxDepth;
            }

            T obj;
            using (StringReader textReader = new System.IO.StringReader(data))
            {
                JsonTextReader reader = new JsonTextReader(textReader);
                obj = (T)serializer.Deserialize(reader, typeof(T));
            }

            return obj;
        }

        public static T FromJSON<T>(this Stream input)
        {
            return FromJSON<T>(input, null);
        }

        public static T FromJSON<T>(this Stream input, int? maxDepth)
        {
            T obj;
            using (StreamReader sReader = new StreamReader(input))
            {
                JsonReader jReader = new JsonTextReader(sReader);
                JsonSerializer serializer = new JsonSerializer();

                if (maxDepth.HasValue)
                {
                    serializer.MaxDepth = maxDepth;
                }

                obj = serializer.Deserialize<T>(jReader);
            }

            return obj;
        }
    }
}

