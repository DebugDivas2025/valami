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
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using valami.valami.Models;

namespace valami.valami.Components
{
    internal interface IPlantingCalendarManager
    {
        IEnumerable<PlantingCalendar> GetPlantingCalendars();
    }

    internal class PlantingCalendarManager : ServiceLocator<IPlantingCalendarManager, PlantingCalendarManager>, IPlantingCalendarManager
    {
        //public IEnumerable<PlantingCalendar> GetPlantingCalendars()
        //{
        //    IEnumerable<PlantingCalendar> t;
        //    using (IDataContext ctx = DataContext.Instance())
        //    {
        //        var rep = ctx.GetRepository<PlantingCalendar>();
        //        t = rep.Get().ToList(); // Fontos!
        //    }
        //    return t;
        //}
        public IEnumerable<PlantingCalendar> GetPlantingCalendars()
        {
            System.Diagnostics.Debug.WriteLine("🌱 GetPlantingCalendars meghívva");
            using (var ctx = DataContext.Instance())
            {
                var sql = "SELECT * FROM PlantingCalendar";
                return ctx.ExecuteQuery<PlantingCalendar>(CommandType.Text, sql).ToList();
            }
        }
        protected override Func<IPlantingCalendarManager> GetFactory()
        {
            return () => new PlantingCalendarManager();
        }
    }
}
