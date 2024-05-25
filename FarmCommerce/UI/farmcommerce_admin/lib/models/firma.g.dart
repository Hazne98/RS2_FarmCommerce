// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'firma.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Firma _$FirmaFromJson(Map<String, dynamic> json) => Firma(
      (json['firmaId'] as num?)?.toInt(),
      json['naziv'] as String?,
      json['adresa'] as String?,
      json['telefon'] as String?,
      json['email'] as String?,
      json['slikaUrl'] as String?,
    );

Map<String, dynamic> _$FirmaToJson(Firma instance) => <String, dynamic>{
      'firmaId': instance.firmaId,
      'naziv': instance.naziv,
      'adresa': instance.adresa,
      'telefon': instance.telefon,
      'email': instance.email,
      'slikaUrl': instance.slikaUrl,
    };
