using System;
using System.Collections.Generic;
using System.Text;

namespace SongIllustrator {
	public interface IContainerView {
		Dictionary<int, IView> ViewList {
			get;
		}
		void Clear();
		void Add(IView item);
		void Remove(IView item);
		void Remove(int index);
		void AddRange(IView[] items);
		void AddRange(List<IView> items);
		int Count {
			get;
			set;
		}
	}
}
