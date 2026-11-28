namespace Simansoft.SiGestao.Nucleo.Tests;

public class InformacaoProdutoTests
{
    [Fact]
    public void Nome_Sempre_ESiGestao()
    {
        Assert.Equal("siGestão", InformacaoProduto.Nome);
    }
}
