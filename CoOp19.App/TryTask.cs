//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Threading.Tasks;

//namespace CoOp19.App
//{
//    public class TryTask<T> where T : class
//    {
//        private ActionResult<T> dflt()
//        {
//            throw new Exception("Exeption not handled");
//        }
//        public async Task<ActionResult<T>> Run(Func<Task<T>> Task, Func<T, ActionResult<T>> Pass, Func<ActionResult<T>> Fail = { throw; } )
//        {
//            T item;
//            ActionResult<T> output;

//            try
//            {
//                item = await Task();
//                output = Pass(item);
//            }
//            catch (Exception)
//            {
//                output = Fail();
//            }

//            return output;
//        }
//    }
//}
