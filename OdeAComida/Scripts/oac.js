$(function () {
    
    var ajaxFormSubmit = function (e) {//o parâmetro "e" será SEMPRE adicionado ao array de parametros em jquery 
        var $form = $(this);
        var opcoes = {//aqui está sendo definido um objeto e suas propriedades
            
            url: $form.attr("action"),
            tipo: $form.attr("method"),
            dados: $form.serialize()
        };
        
        //faz as chamadas assíncronas: done é uma função de callback quando a requisição foi concluída e bem sucedida, que popula a propriedade dados
        $.ajax(opcoes).done(function (dados) {
            var $target = $($form.attr("data-oac-target"));//target é o elemento DOM na página que será alterado
            var $htmlNovo = $(dados);
            $target.replaceWith($htmlNovo);//substitui o alvo com os dados recebidos
            $htmlNovo.effect("highlight");
            
        });

        e.preventDefault();//evita que o navegador realize a ação padrão (refazer toda a página)
    };

    var submitAutoCompleteForm = function (event, ui) {//os parâmetros têm os valores passados pelo autocomplete
        var $input = $(this);
        $input.val(ui.item.label);//define o valor do input

        var $form = $input.parents("form:first");//busca os elementos DOM superioes hierarquicamente ao form e pega o primeiro form, caso haja vários form dentro de outros
        $form.submit();
    };

    var criarAutoCompletar = function () {
        var $input = $(this);

        var options = {
            source: $input.attr("data-oac-autocomplete"),//informa ONDE pegar os dados
            select: submitAutoCompleteForm//chama  função quando o evento SELECT acontece
        };

        $input.autocomplete(options);//autocomplete é um método da API do jquery UI
    };

    var getPage = function () {
        var $self = $(this);

        var options = {
            url: $self.attr("href"),
            dados: $("form").serialize(),//considera os dados da busca manual na paginação
            tipo: "get"
        };

        $.ajax(options).done(function (dados) {
            var target = $self.parents("div.pagedList").attr("data-otf-target");
            $(target).replaceWith(dados);
        });
        return false;

    };

    $("form[data-oac-ajax='true']").submit(ajaxFormSubmit);//realiza o submit de qualquer formulário com o atributo data-oac-ajax definido como "true"(evento submit)

    $("input[data-oac-autocomplete]").each(criarAutoCompletar);//chama a função criarAutoCompletar para cada input com o atributo data-oac-autocompletar

    $(".main-content").on("click", ".pagedList a", getPage);//refazendo apenas a subseção da página com o resultado da busca (main-content) e adiciona o evento click através do método "on" do jQuery
    //.main-content está na view _Layout com o comando @RenderBody()

});