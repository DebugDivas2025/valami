/*
' Copyright (c) 2025 DebugDivas
'  All rights reserved.
' 
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
' DEALINGS IN THE SOFTWARE.
' 
*/

using DotNetNuke.Data;
using DotNetNuke.Framework;
using System.Collections.Generic;
using valami.valami.Models;

namespace valami.valami.Components
{
    internal interface IOrderManager
    {
        IEnumerable<Order> GetOrders();
        Order GetOrder(int itemId, int moduleId);
        Order GetOrder(int itemId);
    }

    internal class OrderManager : ServiceLocator<IOrderManager, OrderManager>, IOrderManager
    {
        public IEnumerable<Order> GetOrders()
        {
            IEnumerable<Order> t;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Order>();
                t = rep.Get();
            }
            return t;
        }

        public Order GetOrder(int itemid, int moduleid)
        {
            Order t;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Order>();
                t = rep.GetById(itemid, moduleid);
            }
            return t;
        }
        public Order GetOrder(int itemId)
        {
            Order t;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Order>();
                t = rep.GetById(itemId);
            }
            return t;
        }



        protected override System.Func<IOrderManager> GetFactory()
        {
            return () => new OrderManager();
        }
    }
}