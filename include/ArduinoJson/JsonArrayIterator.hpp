// Copyright Benoit Blanchon 2014
// MIT License
//
// Arduino JSON library
// https://github.com/bblanchon/ArduinoJson

#pragma once

#include "Internals/JsonArrayNode.hpp"

namespace ArduinoJson {

class JsonArrayIterator {
 public:
  explicit JsonArrayIterator(Internals::JsonArrayNode *node) : _node(node) {}

  JsonValue &operator*() const { return _node->value; }
  JsonValue *operator->() { return &_node->value; }

  bool operator==(const JsonArrayIterator &other) const {
    return _node == other._node;
  }

  bool operator!=(const JsonArrayIterator &other) const {
    return _node != other._node;
  }

  JsonArrayIterator &operator++() {
    if (_node) _node = _node->next;
    return *this;
  }

 private:
  Internals::JsonArrayNode *_node;
};
}