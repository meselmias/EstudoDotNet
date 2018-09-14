$(function(){
    $("input[data-tipo='cnpj']").mask("000.000.000-00");
    $("input[data-tipo='data']").mask("00/00/0000");
    $("input[data-tipo='moeda']").mask("000.000.000,00", {reverse:true});
});