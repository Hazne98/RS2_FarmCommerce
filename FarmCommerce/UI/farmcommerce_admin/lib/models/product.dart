import 'package:json_annotation/json_annotation.dart';

part 'product.g.dart';

@JsonSerializable()
class Product {
  int? proizvodId;
  String? naziv;
  String? opis;
  double? cena;
  String? slikaUrl;
  int? firmaId;
  Product(this.proizvodId, this.naziv, this.opis, this.cena, this.slikaUrl, this.firmaId);

  /// A necessary factory constructor for creating a new User instance
  /// from a map. Pass the map to the generated `_$UserFromJson()` constructor.
  /// The constructor is named after the source class, in this case, User.
  factory Product.fromJson(Map<String, dynamic> json) => _$ProductFromJson(json);

  /// `toJson` is the convention for a class to declare support for serialization
  /// to JSON. The implementation simply calls the private, generated
  /// helper method `_$UserToJson`.
  Map<String, dynamic> toJson() => _$ProductToJson(this);
}

//       "proizvodId": 0,
//       "naziv": "string",
//       "opis": "string",
//       "cena": 0,
//       "slikaUrl": "string",
//       "firmaId": 0,
//       "stateMachine": "string"