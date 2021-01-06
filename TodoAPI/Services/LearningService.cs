using System;
using System.Threading.Tasks;
using System.Net.Http;

namespace TodoApi.Services
{

    public class Bar
    {
        public string foo { get; set; }
    }

    public class LearningService {

        public Bar GetBar()
        {
            return new Bar { foo = "bar" };
        }
    }

}