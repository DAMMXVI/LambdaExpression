    class Program
    {
        static void Main(string[] args)
        {
            var people = new People() { id = 5, name = "Alper" };


            //Dışarıdan People nesne alan ve id değerini 1 ile karşılaştırıp geriye bool değer döndüren bir lambda.
            Expression<Func<People, bool>> lambda = p => p.id > 1;
            // bir değer alıp bool dönen foksiyonlara genel olarak Predicate denir. Expression'ı derleyerek bir fonksiyon elde ediyoruz.
            Func<People, bool> predicate = lambda.Compile();
            // bir people ile test edelim
            
            var result = predicate(people);
            Console.WriteLine(result);  //True!
            
        }
    }

    class People
    {
        public string name;
        public int id;
    }
