#include <stdio.h>

int main()
{
    float a, b, c;
    
    printf("Digite o primeiro lado: ");
    scanf("%f", &a);
    
    printf("\nDigite o segundo lado: ");
    scanf("%f", &b);
    
    printf("\nDigite o terceiro lado: ");
    scanf("%f", &c);
    
    if(a < b + c && b < a + c && c < a +b)
    {
        if(a == b && b == c && c == a)
        {
            printf("\nÉ um triâgulo equilátero.");
        }
        else if(a == b || a == c || b == c)
        {
            printf("\nÉ um triângulo isósceles.");
        }
        else if(a != b && b!= c)
        {
            printf("\nÉ um triângulo escaleno.");
        }
    else 
    {
        printf("Não é um triângulo");
    }
    
    }
return 0;

}
