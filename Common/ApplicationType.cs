using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject;
using System.Threading.Tasks;

namespace ReactiveWPFUserControl.Common {
	
	public interface ApplicationType {

		StandardKernel AppComponent { get; }			
	}
}
