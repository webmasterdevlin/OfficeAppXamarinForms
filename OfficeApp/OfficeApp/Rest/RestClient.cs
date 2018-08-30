using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OfficeApp.Rest
{
    public class RestClient<TResult> : IRestClient<TResult> where TResult : class 
    {

    }
}
