class Personagem
{
    private int forca;
    private int vida;
    private Avatar avatar;

    public Personagem(int forca, int vida, string tipo)
    {
        avatar = Avatar.GetAvatar(tipo);
        
    }

}