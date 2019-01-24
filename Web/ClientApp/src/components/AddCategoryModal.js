import React, {PureComponent} from 'react'
import {Modal, Form, Input, Button, Icon, Divider} from 'antd'
import 'antd/dist/antd.css';
import {GenerateUid} from '../helpers'
import ExtraField from './ExtraField';

const FormItem = Form.Item
const { TextArea } = Input;

class AddCategoryModal extends PureComponent {

    state = {
        extraFields : []
    }

    onSubmit = ()=>{
        const {form, onCreate, onClose} = this.props
        const {extraFields} = this.state
        form.validateFields((err, values) => {
            if (err) {
              return;
            }

            values.CategoryFieldNames = extraFields.map(i=>i.name)
            values.CategoryFieldTypes = extraFields.map(i=>i.type)
      
            onCreate(values)
            form.resetFields();
            onClose()
        });
    }

    add = ()=>{
        const {extraFields} = this.state
        const newExtraFields = extraFields.concat({id: GenerateUid(), name: '',  type: null})
        this.setState({
            extraFields: newExtraFields
        })
    }

    remove = (id)=>{
        const {extraFields} = this.state
        const updatedValue = extraFields.filter(i=>(i.id !== id))
        this.setState({
            extraFields: updatedValue
        })
    }

    onChangeExtraField = (updatedItem) => {
        console.log(updatedItem)
        const {extraFields} = this.state
        const updatedValue = extraFields.map(i=>{
            if (i.id === updatedItem.id){
                return updatedItem
            }
            return i
        });
        this.setState({
            extraFields: updatedValue
        })
    }
    render(){
        const {onClose, form} = this.props
        const {extraFields} = this.state
        const { getFieldDecorator } = form
        
        console.log(extraFields)
        const extraFieldsItems = extraFields.map(x=>{
            return (
                <span key={x.id}>
                    <ExtraField item={x} onChange={this.onChangeExtraField}/>
                    <Button onClick={()=>this.remove(x.id)} type="danger">Remove extra field</Button>
                </span>)
        })
        return(
            <Modal
                visible
                title="Add category"
                onCancel={onClose}
                onOk={this.onSubmit}>
                <Form>
                    <FormItem
                       label="Name">
                            {getFieldDecorator('name', {
                                rules: [{ required: true, message: 'Please input the title' }],
                            })(
                                <Input />
                            )}
                    </FormItem>
                    <FormItem
                       label="Category information">
                            {getFieldDecorator('description', {
                                rules: [{ required: true, message: 'Please input cateory information' }],
                            })(
                                <TextArea rows={3} />
                            )}
                    </FormItem>
                    {extraFieldsItems}
                    <Divider/>
                    <FormItem>
                        <Button type="dashed" onClick={this.add} style={{ width: '60%' }}>
                            <Icon type="plus" /> Add field
                        </Button>
                    </FormItem>


                </Form>
            </Modal>
        )
    }
}

export default Form.create() (AddCategoryModal)