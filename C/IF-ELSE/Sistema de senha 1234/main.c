#include <stdio.h>

int main()
{
    int senha;
    
    printf("Digite a senha: ");
    scanf("%d", &senha);
    
    if (senha == 1234) {
        printf("\nAcesso Permitido");
    }
    else{
        printf("\nAcesso Negado");
    }

    return 0;
}
