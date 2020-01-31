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

            // parametremizi tanımlayalım, diğer Expression'lar bu parametreye isimle değil, bu değişken ile ulaşmak zorundalar
            var prm = Expression.Parameter(typeof(People));
            var lambda2 = Expression.Lambda(
                Expression.MakeBinary(                      // Lambda Body özelliği bir BinaryExpression
                    ExpressionType.GreaterThan,             // Büyüktür karşılaştırması yapacağız
                    Expression.PropertyOrField(prm, "Id"),  // Dışarıdan gelen parametrenin Id özelliği
                    Expression.Constant(1)                  // sabit değerimizi ConstantExpression ile geçiyoruz
                ),
                prm     // Lambda'nın bu parametreyi dışarıdan beklediğini belirtiyoruz
            );
            //Böylece runtime'da bir lambda expression oluşturduk.
            
            Console.ReadKey();
        }
    }

    class People
    {
        public string name;
        public int id;
    }
