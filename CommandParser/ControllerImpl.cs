using System;

namespace CommandParser
{
	public class ControllerImpl : Controller
	{
		private String alias;
		public ControllerImpl () {						
		}

		public bool onPlay () {
			Console.WriteLine(String.Format("onPlay"));
			return true;
		}

		public bool onPlayNext () {
			Console.WriteLine(String.Format("onPlayNext"));
			return true;
		}

		public bool onWriteText (String text, int x, int y) {
			Console.WriteLine(String.Format("onWriteText: text={0:s} x={1:d} y={1:d}", text, x, y));
			return true;
		}

		public bool onUnfreeze() {
			Console.WriteLine(String.Format("onUnfreeze"));
			return true;
		}

		public bool onFreeze(int ms) {
			Console.WriteLine(String.Format("onFreeze: ms={0:d}", ms));
			return true;
		}

		public bool onGoTo (int step) {
			Console.WriteLine(String.Format("onGoTo: step={0:d}", step));
			return true;			
		}

		public bool onSetCameraXYZ (int x, int y, int z) {
			Console.WriteLine(String.Format("onSetCameraXYZ: x={0:d} y={1:d} z={1:d}", x, y, z));
			return true;
		}

		public void setAlias(String alias) {
			this.alias = alias;
		}

		public String getAlias() {
			return alias;
		}
			
	}
}

