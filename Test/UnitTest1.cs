using calculadora_tdd;

namespace Test
{
    public class UnitTest1
    {
        public Calculadora ConstruindoClasse()
        {
            string data = "09/09/2024";
            Calculadora calc = new Calculadora("09/09/2024");
            return calc;
        }

        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(4, 5, 9)]
        public void TestSomar(int num1, int num2, int resultado)
        {
            Calculadora calc =  ConstruindoClasse();

            int resultadoEsperado = calc.Somar(num1, num2);

            Assert.Equal(resultado, resultadoEsperado);
        }

        [Theory]
        [InlineData(2, 1, 1)]
        [InlineData(5, 4, 1)]
        public void TestSubtrair(int num1, int num2, int resultado)
        {
            Calculadora calc =  ConstruindoClasse();

            int resultadoEsperado = calc.Subtrair(num1, num2);

            Assert.Equal(resultado, resultadoEsperado);
        }

        [Theory]
        [InlineData(1, 2, 2)]
        [InlineData(4, 5, 20)]
        public void TestMultiplicar(int num1, int num2, int resultado)
        {
            Calculadora calc = ConstruindoClasse();

            int resultadoEsperado = calc.Multiplicar(num1, num2);

            Assert.Equal(resultado, resultadoEsperado);
        }

        [Theory]
        [InlineData(2, 1, 2)]
        [InlineData(10, 2, 5)]
        public void TestDividir(int num1, int num2, int resultado)
        {
            Calculadora calc = ConstruindoClasse();

            int resultadoEsperado = calc.Dividir(num1, num2);

            Assert.Equal(resultado, resultadoEsperado);
        }

        [Fact]
        public void TestarDivisaoPorZero()
        {
            Calculadora calc = ConstruindoClasse();

            Assert.Throws<DivideByZeroException>(() => calc.Dividir(3, 0) );
        }

        [Fact]
        public void TestarHistorico()
        {
            Calculadora calc = ConstruindoClasse();

            calc.Somar(1, 2);
            calc.Subtrair(3, 2);
            calc.Multiplicar(1, 2);
            calc.Dividir(4, 2);

            var lista = calc.Historico();

            Assert.NotEmpty(lista);
            Assert.Equal(3, lista.Count);
        }

        //Testes Adicionados
        //Teste de Limite - Para testar a capacidade da calculadora

        [Theory]
        [InlineData(int.MaxValue, 1, int.MinValue)] 
        [InlineData(int.MinValue, -1, int.MaxValue)] 
        public void TestSomarLimites(int num1, int num2, int resultado)
        {
            Calculadora calc = ConstruindoClasse();
            int resultadoEsperado = calc.Somar(num1, num2);
            Assert.Equal(resultado, resultadoEsperado);
        }

        //Multiplicação por Zero

        [Theory]
        [InlineData(0, 5, 0)]
        [InlineData(10, 0, 0)]
        public void TestMultiplicarPorZero(int num1, int num2, int resultado)
        {
            Calculadora calc = ConstruindoClasse();
            int resultadoEsperado = calc.Multiplicar(num1, num2);
            Assert.Equal(resultado, resultadoEsperado);
        }

        //Somando com Números Negativos

        [Theory]
        [InlineData(-1, -1, -2)]
        [InlineData(-10, 5, -5)]
        public void TestSomarComNumerosNegativos(int num1, int num2, int resultado)
        {
            Calculadora calc = ConstruindoClasse();
            int resultadoEsperado = calc.Somar(num1, num2);
            Assert.Equal(resultado, resultadoEsperado);
        }

        //Dividindo com o Zero

        [Theory]
        [InlineData(0, 2, 0)]
        public void TestDividirZero(int num1, int num2, int resultado)
        {
            Calculadora calc = ConstruindoClasse();
            int resultadoEsperado = calc.Dividir(num1, num2);
            Assert.Equal(resultado, resultadoEsperado);
        }
    }
}