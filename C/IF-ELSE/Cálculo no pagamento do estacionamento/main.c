#include <stdio.h>

int main()
{
    float tempo_permanecia, horario_entrada, horario_saida;
    
    printf("Digite o horário de entrada: ");
    scanf("%f", &horario_entrada);
    
    printf("\nDigite o horário de saída: ");
    scanf("%f", &horario_saida);
    
    tempo_permanecia = horario_saida-horario_entrada;
    
    if(tempo_permanecia <= 1) {
        printf("\nO valor a ser pago é de R$8,00");
    }
    
    else if (tempo_permanecia == 2){
        printf("\nO valor a ser pago é de R$15,00");
    }
    
    
    else{
        tempo_permanecia = tempo_permanecia*5;
        printf("\nO valor a ser pago é de R$%0.2f", tempo_permanecia);
    }
    
    return 0;
}
