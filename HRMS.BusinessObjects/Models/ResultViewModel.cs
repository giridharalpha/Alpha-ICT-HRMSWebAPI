using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace HRMS.BusinessObjects.Models
{  
       
        public class ResultViewModel<T>
        {
            public T Result { get; set; }
            public HttpStatusCode ResponseCode { get; set; }
            public string  Message { get; set; }
            public string UserMessage { get; set; }
           
            public ResultViewModel()
            {
            }
            public ResultViewModel(T result, string message, string userMessage)
            {
                this.Result = result;
                this.Message = message;
                this.UserMessage = userMessage;
            }
            public ResultViewModel(T result, HttpStatusCode responseCode, string message, string userMessage)
            {
                this.Result = result;
                this.ResponseCode = responseCode;
                this.Message = message;
                this.UserMessage = userMessage;
            }

        }

        public enum Message
        {
            Success,
            NotFound,
            AlreadyExists,
            Exception,
            Failure,
            GatewayConnectionFailed,
            DataBaseError,
            NoData,
            unauthorized,
            TimeOut
        }
    public class UserMessage
    {
        public static string RecordSavedMessage { get=>"Record saved successfully"; }
        public static string RecordUpdatedMessage { get => "Record updated successfully"; }
        public static string RecordDeletedMessage { get => "Record deleted successfully"; }
        public static string RecordNotFoundMessage { get => "Record not found"; }
        public static string RecordAlreadyExistsMessage { get => "Record already exists..!!"; }
        public static string Success { get => "Query successfuly executed..!!"; }
        public static string InvalidData { get => "Data is not valid..!!"; }
    }
    
}
