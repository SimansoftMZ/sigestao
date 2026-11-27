namespace Simansoft.SiGestao.Nucleo.Tests;

public class InformacaoProdutoTests
{
    [Fact]
    public void Nome_E_SiGestao()
    {
        Assert.Equal("siGestão", InformacaoProduto.Nome);
    }
}
