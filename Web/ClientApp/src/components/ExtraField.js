import React, {PureComponent} from 'react'
import {Form, Input, Select, Divider} from 'antd'
import 'antd/dist/antd.css';
import {CategoryFieldTypes} from '../constants'

const Option = Select.Option
const FormItem = Form.Item

class ExtraField extends PureComponent {

    onChangeProperty = (propName)=>{
        const {onChange, item} = this.props
        return (e)=>{
            console.log(e)
            const result = {...item}
            result[propName] = e && e.target ? e.target.value: e
            onChange(result)
        }
    }

    render(){
        const {item} = this.props
        return (
                <span key={item.id} className="form-inline">
                <Divider />
                <FormItem label="Name of extra field">
                    <Input 
                    onChange={this.onChangeProperty('name')}
                    value={item.name}/>
                </FormItem>
                <FormItem label="Type of extra field">
                    <Select value={item.type}  onChange={this.onChangeProperty('type')}>
                        {CategoryFieldTypes && CategoryFieldTypes.map(i=>{
                            return (<Option key={i.value} value={i.value}>{i.text}</Option>)
                        })}
                    </Select>
                </FormItem>
            </span>)
    }
}

export default Form.create() (ExtraField)