using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using CAN驱动库;



namespace 天琴.Function
{
    class Threadstest
    {
        static IntPtr RXthread_handle;
        public void getrxHandle(IntPtr channel_handle)
        {
            
            
                RXthread_handle = channel_handle;
            
        }

        

        static void CAN收()
        {
<<<<<<< HEAD
            //CANDLL函数.ZCAN_Receive(RXthread_handle, ptr, 1, 50);
=======
            CANDLL函数.ZCAN_Receive(RXthread_handle, ptr, 1, 50);
>>>>>>> 7ec75c3fbac34765fbac3dbff452a88212e1251f

        }
        Thread CANRXTheads = new Thread(CAN收);

    }
}
