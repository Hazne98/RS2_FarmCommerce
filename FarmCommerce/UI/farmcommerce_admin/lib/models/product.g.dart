// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'product.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Product _$ProductFromJson(Map<String, dynamic> json) => Product(
      (json['proizvodId'] as num?)?.toInt(),
      json['naziv'] as String?,
      json['opis'] as String?,
      (json['cena'] as num?)?.toDouble(),
      json['slikaUrl'] as String?,
    );

Map<String, dynamic> _$ProductToJson(Product instance) => <String, dynamic>{
      'proizvodId': instance.proizvodId,
      'naziv': instance.naziv,
      'opis': instance.opis,
      'cena': instance.cena,
      'slikaUrl': instance.slikaUrl,
    };
