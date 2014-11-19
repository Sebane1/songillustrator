using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SongIllustrator {
	public class Launchpad {
		private int _density;

		LightPad _lightPad;
		private bool _listenToMidi = true;
		private bool _editMode;
		MidiDriver _port;
		public LightPad LightPad {
			get {
				return _lightPad;
			}
			set {
				_lightPad = value;
			}
		}
		public int Density {
			get {
				return _density;
			}
			set {
				_density = value;
			}
		}
		private List<FrameData> _frameData = new List<FrameData>();

		public List<FrameData> FrameData {
			get {
				return _frameData;
			}
			set {
				_frameData = value;
			}
		}
		private System.Threading.Thread _thread;

		public System.Threading.Thread Thread {
			get {
				return _thread;
			}
			set {
				_thread = value;
			}
		}
		public bool EditMode {
			get {
				return _editMode;
			}
			set {
				_editMode = value;
			}
		}

		public bool ListenToMidi {
			get {
				return _listenToMidi;
			}
			set {
				_listenToMidi = value;
			}
		}
		public MidiDriver Port {
			get {
				return _port;
			}
			set {
				_port = value;
			}
		}
		/// <summary>
		/// Shifts the selected frames for the virtual launchpad.
		/// </summary>
		/// <param name="baseStamp"></param>
		/// <param name="frameTimes"></param>
		public void ShiftFrames(decimal baseStamp, List<FrameData> frameTimes) {
			for (int i = 0; i < frameTimes.Count; i++) {
				decimal difference = 0;
				FrameData frame = frameTimes[i] as FrameData;
				if (i < frameTimes.Count - 1) {
					FrameData frame2 = (frameTimes[i + 1] as FrameData);
					difference = frame2.TimeStamp - frame.TimeStamp;
				}
				_frameData[frame.Index].TimeStamp -= frame.TimeStamp - baseStamp;
				baseStamp += difference;
			}
		}

		/// <summary>
		/// Syncs the selected frames for the virtual launchpad.
		/// </summary>
		/// <param name="baseStamp">The time stamp to start from.</param>
		/// <param name="frameTimes">The skeleton frame data to reference time stamps and indexes off of. Colour data is not used.</param>
		public void SyncFrames(decimal baseStamp, List<FrameData> frameTimes) {
			int frameIndex = 0;
			List<FrameData> tempFrames = new List<FrameData>();
			FrameData data = new FrameData();
			data.TimeStamp = (frameTimes[0] as FrameData).TimeStamp - baseStamp;
			tempFrames.Add(data);
			foreach (FrameData item in frameTimes) {
				tempFrames.Add(item);
			}
			for (int i = 0; i < frameTimes.Count; i++) {
				if (tempFrames[0] == frameTimes[i]) {
					frameIndex = i > 0 ? i - 1 : 0;
					break;
				}
			}
			for (int i = 0; i < frameTimes.Count; i++) {
				_frameData[frameTimes[i].Index].TimeStamp = tempFrames[frameIndex].TimeStamp + baseStamp * (i + 1);
			}
		}

		/// <summary>
		/// Duplicates the selected frames for the virtual launchpad.
		/// </summary>
		/// <param name="baseStamp">The time stamp to start from.</param>
		/// <param name="frameTimes">>The skeleton frame data to reference time stamps and indexes off of. Colour data is not used.</param>
		public void DuplicateFrames(decimal baseStamp, List<FrameData> frameTimes) {
			decimal currentCount = baseStamp;
			decimal difference = 0;
			if (_frameData.Count != 0) {
				currentCount = _frameData[_frameData.Count - 1].TimeStamp;
			}
			for (int i = 0; i < frameTimes.Count; i++) {
				FrameData item = _frameData[frameTimes[i].Index];
				FrameData data = new FrameData();
				data.Colours = item.Colours;
				data.Index = _frameData.Count;
				if (i < frameTimes.Count - 1) {
					FrameData frame2 = _frameData[frameTimes[i + 1].Index];
					difference = frame2.TimeStamp - item.TimeStamp;
				}
				currentCount += difference;
				data.TimeStamp = currentCount;
				_frameData.Add(data);
			}
		}
		/// <summary>
		/// Duplicates the selected frames in reverse order.
		/// </summary>
		/// <param name="baseStamp">The starting note placement.</param>
		/// <param name="frameTimes">The skeleton frame data to reference time stamps and indexes off of. Colour data is not used.</param>
		internal void ReverseDuplicateFrames(decimal baseStamp, List<FrameData> frameTimes) {
			decimal currentCount = baseStamp;
			decimal difference = 0;
			if (_frameData.Count != 0) {
				currentCount = _frameData[_frameData.Count - 1].TimeStamp;
			}
			for (int i = 0; i < frameTimes.Count; i++) {
				FrameData item = _frameData[frameTimes[frameTimes.Count - 1 - i].Index];
				FrameData data = new FrameData();
				data.Colours = item.Colours;
				data.Index = _frameData.Count;
				if (i < frameTimes.Count - 1) {
					FrameData frame2 = _frameData[frameTimes[i + 1].Index];
					difference = frame2.TimeStamp - _frameData[frameTimes[i].Index].TimeStamp;
				}
				currentCount += difference;
				data.TimeStamp = currentCount;
				_frameData.Add(data);
			}
		}
	}
}