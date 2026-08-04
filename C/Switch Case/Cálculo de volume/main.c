#include <stdio.h>

#define pi 3.14

int main()
{
    int opcao;
    float lado, comprimento,largura, altura, raio_base,altura_cl, conta=0; 
    
    printf("Escolha oq vc quer calcular");
    printf("\n(1) Volume cúbico \n(2) Volume paralelepídeo \n(3) Volume cilindro\n");
    printf("Digite uma opção: ");
    scanf("%d", &opcao);
    
    switch(opcao){
        case 1:
        
        printf("\nDigite o lado do cubo:");
        scanf("%f", &lado);
        
        conta = lado * lado * lado;
        
        printf("\nO valor do volume cúbico é: %0.2f", conta);
        
        break;
        
        case 2:
        
        printf("\nDigite o comprimento: ");
        scanf("%f", &comprimento);
        
        printf("\nDigite o altura: ");
        scanf("%f", &altura);
        
        printf("\nDigite o comprimento: ");
        scanf("%f", &largura);
        
        conta = largura * altura * comprimento;
        
        printf("\nO valor do volume paralelepídeo é: %0.2f", conta);
        
        break;
        
        case 3:
        
        printf("\nDigite o raio base: ");
        scanf("%f", &raio_base);
        
        printf("\nDigite a altura_cl: ");
        scanf("%f", &altura_cl);
        
        conta = pi *(raio_base * raio_base)*altura_cl;
        
        printf("\nO valor do volume do clilindro é: %0.2f", conta);
        
        break;
        
        default:
        printf("Digitação inválida");
        
    }
        
    return 0;
}
