﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactiveControls.Common {
	
	public interface LogType {

		bool isLogEnabled();
		string getClassTag();
	}
}
