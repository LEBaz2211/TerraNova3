using System;
namespace TerraNova3.Models
{
	public class Entity
	{
		public int Row;
        public int Col;
        public Image Image;

		public Entity(int row, int col, string imageFile)
		{
            Image image = new Image();
            image.Source = imageFile;
        }
	}
}

