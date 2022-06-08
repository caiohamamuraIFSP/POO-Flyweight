using System.Collections.Generic;
using System.Drawing;


class Avatar
{
    Image imagem;

    private static Dictionary<string, Avatar> cacheAvatares = new Dictionary<string, Avatar>();


    private Avatar(Image imagem) {
        this.imagem = imagem;
    }
    
    public static Avatar GetAvatar(string tipo)
    {
        if (cacheAvatares.ContainsKey(tipo))
            return cacheAvatares[tipo];
        else 
        {
        Image imagem;
        if (tipo == "Guerreiro")
        {
            imagem = Image.FromFile("guerreiro.png");
        }
        else
        {
            imagem = Image.FromFile("mago.png");
        }

        Avatar avatar = new Avatar(imagem);
        cacheAvatares.Add(tipo, avatar);

        return avatar;
        }
    }
}