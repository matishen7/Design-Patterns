using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns.Builder
{
    internal class FunctionalBuilderProgram
    {
        public abstract class GenericFunctionalBuilder<TSubject, TSelf>
        where TSubject : new()
        where TSelf : GenericFunctionalBuilder<TSubject, TSelf>
        {
            /// <summary>
            ///  To hold a list fluent actions.
            /// </summary>
            private readonly List<Func<TSubject, TSubject>> actions = new List<Func<TSubject, TSubject>>();


            /// <summary>
            /// Helps in adding functions to a list of action.
            /// </summary>
            /// <param name="action"></param>
            /// <returns></returns>


            public TSelf Do(Action<TSubject> action)
            {
                AddActions(action);
                return (TSelf)this;
            }


            /// <summary>
            /// Adds all fuctions to a list
            /// </summary>
            /// <param name="action"></param>
            /// <returns></returns>
            private TSelf AddActions(Action<TSubject> action)
            {
                actions.Add(p => {
                    action(p);
                    return p;
                });
                return (TSelf)this;
            }


            /// <summary>
            /// Builds Subject In Very Fluent Way
            /// </summary>
            /// <returns></returns>
            public TSubject Build()
            {
                return actions.Aggregate(new TSubject(), (p, f) => f(p));
            }


        }

        class Equipment
        {
            private string type = string.Empty;
            private string make = string.Empty;
            private string model = string.Empty;
            private string industry = string.Empty;


            public string Type { get => type; set => type = value; }
            public string Make { get => make; set => make = value; }
            public string Model { get => model; set => model = value; }
            public string Industry { get => industry; set => industry = value; }
        }

        /// <summary>
        /// One can't modify or inherit but one can extend anytime.
        /// </summary>
        sealed class EquipmentBuilder : GenericFunctionalBuilder<Equipment, EquipmentBuilder>
        {
            /// <summary>
            /// Industry 
            /// </summary>
            /// <param name="industry"></param>
            /// <returns></returns>
            public EquipmentBuilder Industry(string industry)
            {
                return Do(e => e.Industry = industry);
            }


            /// <summary>
            /// Equipment Type
            /// </summary>
            /// <param name="equipmentType"></param>
            /// <returns></returns>
            public EquipmentBuilder EquipmentType(string equipmentType)
            {
                return Do(e => e.Type = equipmentType);
            }


            /// <summary>
            /// Equipment Make
            /// </summary>
            /// <param name="equipmentMake"></param>
            /// <returns></returns>
            public EquipmentBuilder EquipmentMake(string equipmentMake)
            {
                return Do(e => e.Make = equipmentMake);
            }


            /// <summary>
            /// Equipment Model
            /// </summary>
            /// <param name="equipmentModel"></param>
            /// <returns></returns>
            public EquipmentBuilder EquipmentModel(string equipmentModel)
            {
                return (Do(e => e.Model = equipmentModel));
            }
        }
    }
}
