using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    public abstract class BaseTest
    {
        protected BaseTest()
        {
            InitializeMocks();
        }

        /// <summary> Mock service initialization </summary>
        protected abstract void InitializeMocks();

    }
}
