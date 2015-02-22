using System;
using System.Collections.Generic;
using System.Text;
using SongIllustrator;
using MonoMac.AppKit;

namespace OSXFactory.Wrappers {
	public class PanelWrapper : ControlWrapper, IPanelView {
		public PanelWrapper() {
			//this.Control = new NSPanel();
		}
		#region IContainerView Members
		Dictionary<int, IView> _viewList = new Dictionary<int, IView>();
		public Dictionary<int, IView> ViewList {
			get {
				return _viewList;
			}
		}

		public void Clear() {
			_viewList.Clear();
		}

		public void Add(IView item) {
			_viewList.Add(_viewList.Count, item);
		}

		public void Remove(IView item) {
			//_viewList.Remove(item);
		}
		public void Remove(int index) {
			_viewList.Remove(index);
		}
		#endregion

		#region IContainerView Members


		public int Count {
			get {
				return _viewList.Count;
			}
			set {
				throw new NotImplementedException();
			}
		}

		#endregion

		#region IContainerView Members


		public void AddRange(IView[] items) {
			foreach (IView item in items) {
				Add(item);
			}
		}

		public void AddRange(List<IView> items) {
			AddRange(items.ToArray());
		}

		#endregion
	}
}
