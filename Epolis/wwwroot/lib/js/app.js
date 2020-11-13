// Author : Aditya Rahman Sidqi
// Date : 09-11-2020

$(document).ready(function() {
	ClassicEditor
    .create( document.querySelector( '#bodymail' ) )
    .then( editor => {
        console.log( editor );
    } )
    .catch( error => {
        console.error( error );
    } );
});