using System;


namespace Interface_example1
{

    interface IQuadcopter_IR
    {
        void Select_comm_method();

    }

    interface IQuadcopter_RF
    {
        void Select_comm_method();
    }

    interface IQuadcopter_Bluetooth
    {
        void Select_comm_method();
    }
    // Implicit implementation 
    class Quadcopter_IR_RF : IQuadcopter_IR, IQuadcopter_RF
    {
        public void Select_comm_method()
        {
            Console.WriteLine("Using both IR and RF");

        }
        // Explicit implementation for method
        void IQuadcopter_IR.Select_comm_method()
        {
            Console.WriteLine("Using ONLY IR from First derived");
        }
        // Explicit implementation for method
        void IQuadcopter_RF.Select_comm_method()
        {
            Console.WriteLine("Using ONLY RF from First Derived");
        }
    }

    class Quadcopter_IR_RF_Bluetooth : IQuadcopter_IR, IQuadcopter_RF, IQuadcopter_Bluetooth
    {
        public void Select_comm_method()
        {
            Console.WriteLine("Using all three:IR, RF, and Bluetooth");

        }
        // Explicit implementation for method
        void IQuadcopter_IR.Select_comm_method()
        {
            Console.WriteLine("Using ONLY IR from Second Derived");
        }
        // Explicit implementation for method
        void IQuadcopter_RF.Select_comm_method()
        {
            Console.WriteLine("Using ONLY RF from Second Derived");
        }
        // Explicit implementation for method
        void IQuadcopter_Bluetooth.Select_comm_method()
        {
            Console.WriteLine("Using ONLY Bluetooth");
        }

    }





    class Program
    {
        static void Main(string[] args)
        {
            // Object of most derived type
            Quadcopter_IR_RF_Bluetooth obj_derv = new Quadcopter_IR_RF_Bluetooth();
            obj_derv.Select_comm_method();

            // Reference of type interface to a derived type
            IQuadcopter_IR obj_ref_IRtype = new Quadcopter_IR_RF();
            obj_ref_IRtype.Select_comm_method();

            // Reference of type interface to a derived type
            IQuadcopter_RF obj_ref_RFtype = new Quadcopter_IR_RF_Bluetooth();
            obj_ref_RFtype.Select_comm_method();

            Console.ReadKey();
        }
    }
}
