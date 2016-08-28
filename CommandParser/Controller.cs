using System;

namespace CommandParser
{
	public interface Controller
	{
		bool onPlay();
		bool onPlayNext();
		bool onWriteText (String s, int x, int y);
		bool onUnfreeze();
		bool onFreeze(int ms);
		bool onGoTo (int step);
		bool onSetCameraXYZ (int x, int y, int z);
		void setAlias(String alias);
		String getAlias();

		//требуется понять в каком формате мы будем оперировать изображениями, звуками. Какими классами можно пользоваться для этого?
		//void onOutImage(Image image, int x, int y)
		//void onGetMicrophone (int n);
		//void onGetScreen();
	}
}

