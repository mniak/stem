package impl

import "github.com/mniak/graphite"

type argument struct {
	param graphite.Parameter
	value graphite.Value
}

func (a argument) Parameter() graphite.Parameter {
	return a.param
}

func (a argument) Value() graphite.Value {
	return a.value
}

func (a argument) Accept(visitor graphite.Visitor) error {
	return visitor.VisitArgument(a)
}

func NewArgument(param graphite.Parameter, value graphite.Value) argument {
	return argument{
		param: param,
		value: value,
	}
}
