import 'package:json_annotation/json_annotation.dart';

part 'firma.g.dart';


@JsonSerializable()
class Firma {
  int? firmaId;
  String? naziv;
  String? adresa;
  String? telefon;
  String? email;
  String? slikaUrl;

  Firma(this.firmaId, this.naziv, this.adresa, this.telefon, this.email, this.slikaUrl);

    /// A necessary factory constructor for creating a new User instance
  /// from a map. Pass the map to the generated `_$UserFromJson()` constructor.
  /// The constructor is named after the source class, in this case, User.
  factory Firma.fromJson(Map<String, dynamic> json) => _$FirmaFromJson(json);

  /// `toJson` is the convention for a class to declare support for serialization
  /// to JSON. The implementation simply calls the private, generated
  /// helper method `_$UserToJson`.
  Map<String, dynamic> toJson() => _$FirmaToJson(this);
}