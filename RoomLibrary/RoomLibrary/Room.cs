namespace RoomLibrary_
{
    public class Room
    {
        
        double roomLength; //длина комнаты
        double roomWidth; //ширина комнаты
       
        public double RoomLength
        {
            get { return roomLength; }
            set { roomLength = value; }
        }

        public double RoomWidth 
        {
            get { return roomWidth; }
            set { roomWidth = value; }
        }
        /// < summary >
        /// Метод вычисляет периметр комнаты
        /// </summary>
        /// <returns>Возвращает значение периметра</returns> Ссылок: 0
        public double RoomPerimeter()
        {
            return 2 * (roomLength + roomWidth);
        }
        /// < summary >
        /// Метод вычисляет площадь комнаты 
        ///  </summary>
        ///  <param name="np">Число человек</param>>
        /// <returns>Возвращает значение площади</returns> Ссылок: 0
       
        public double RoomArea() 
        {
                return roomLength * roomWidth;
        }
        public double PersonArea(int np)
        {
            return RoomArea() / np;
        }

        public  virtual  string Info()
        {
            return "Комната площадью" + RoomArea() + "кв.м";
        }
        public class LivigRoom : Room
        {
            int numWin;
             
            public int NumWin
            { get { return numWin; } set { numWin = value; } }

            public override  string Info()
            {
                return "Жилая комната" + RoomArea() + "кв.м" + numWin + "окнами";
            }
        }

        public class Office: Room
        {
            int numSockets;

            public int NumSockets
            { get{ return numSockets; } set { numSockets = value; } }

            public int NumWorkplaces()
            {
                int num = Convert.ToInt32(Math.Truncate(RoomArea() / 4.5));
                return Math.Min(NumSockets, num);

                
            }
            public  override string Info()
            {
                return "Офис на " + NumWorkplaces() + "рабочих мест";
            }


        }
    }
}