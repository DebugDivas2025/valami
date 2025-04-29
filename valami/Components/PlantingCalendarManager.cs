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
        public IEnumerable<PlantingCalendar> GetPlantingCalendars()
        {
            IEnumerable<PlantingCalendar> t;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<PlantingCalendar>();
                t = rep.Get().ToList(); // Fontos!
            }
            return t;
        }

        protected override Func<IPlantingCalendarManager> GetFactory()
        {
            return () => new PlantingCalendarManager();
        }
    }
}
