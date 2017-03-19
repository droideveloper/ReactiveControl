using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject;
using System.Threading.Tasks;

namespace ReactiveControls.Common {
	
	public interface ApplicationType {

		StandardKernel AppComponent { get; }			
	}
}
