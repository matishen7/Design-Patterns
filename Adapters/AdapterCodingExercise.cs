//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Design_Patterns.Adapters
//{
//    public class AdapterCodingExercise
//    {
//        public class Square
//        {
//            public int Side;
//        }

//        public interface IRectangle
//        {
//            int Width { get; }
//            int Height { get; }
//        }

//        public static class ExtensionMethods
//        {
//            public static int Area(this IRectangle rc)
//            {
//                return rc.Width * rc.Height;
//            }
//        }

//        public class SquareToRectangleAdapter : IRectangle
//        {
//            public SquareToRectangleAdapter(Square square)
//            {
//                // todo
//            }

//            public int Width => throw new NotImplementedException();

//            public int Height => throw new NotImplementedException();
//            // todo
//        }
//    }
//}
