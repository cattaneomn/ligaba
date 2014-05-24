<?php 
var_dump( $_FILES );

$uploaddir = './';
$uploadfile = $uploaddir . basename($_FILES['userfile']['name']);

if (move_uploaded_file($_FILES['userfile']['tmp_name'], $uploadfile)) {
    echo "El archivo es válido y fue cargado exitosamente.\n";
} else {
    echo "Posible ataque de carga de archivos!\n";
}

?>