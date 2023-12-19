using System;

namespace SalesWebMvc.Models.ViewModels //namespace para os nossos modelos de view
{
    public class ErrorViewModel //classe para o modelo de view de erro
    {
        public string RequestId { get; set; } //propriedade para o id interno do pedido
        public string Message  { get; set; } //propriedade para a mensagem

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId); //propriedade para mostrar o id do pedido
    }
}