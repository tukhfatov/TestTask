import React, { Component } from 'react';
import {Select, Button, Form, Divider, Input, notification} from 'antd'
import 'antd/dist/antd.css';
import axios from 'axios'

const FormItem = Form.Item
const Option = Select.Option
const { TextArea } = Input;

class AddItem extends Component {

    state = {
        categories: [],
        fields: []
    }

    constructor(props){
        super(props)
    }

    loadCategories = async ()=>{
        try{
            const response = await axios.get('/api/category')
            this.setState({
                categories: response.data.data
            })
        }catch(error){
            notification.error({ 
                message: "Error",
                description: "Erorr occured, please try again"})
        }
    }
  componentWillMount = async () =>{
    await this.loadCategories();
  }

  onSubmit =()=>{
    const {form} = this.props
    const {fields} = this.state
    let isValid = true
    fields.forEach(i=>{
        if (i.value === null || i.value ===undefined){
            notification.error({ 
                message: "Empty value",
                description: "Please fill all fields"})
            isValid = false;
        }
    })
    form.validateFields( async (err, values) => {
        if (err || !isValid) {
          return;
        }

        var postData = {Name: values.name, Description: values.description, Price: values.price,
            Category: values.category, CategoryFieldIds: fields.map(i=>i.id), CategoryValues: fields.map(i=>i.value)}
        console.log(postData)
        try{
            await axios.post('/api/item', postData)
            notification.success({ 
                message: "Success", 
                description:"Item has been successfully created"
            })
            form.resetFields();

        }catch(error){
        notification.error({ 
            message: "Error",
            description: "Erorr occured, please try again"})
    
        }
        console.log(values)
        console.log(fields)
 
    });
    }

    onSelect = (value)=>{
        const {categories} = this.state
        const category = categories.filter(i=>i.id === value)[0]

        this.setState({
            fields: category.categoryFields
        })
    }

    onItemChange = (index)=>{
        const {fields} = this.state
        return (e)=>{
            const updateValue = fields.map(i=>{
                if(i.id == index){
                    i.value = e.target.value
                }
                return i
            })
            this.setState({
                fields: updateValue
            })
        }
    }
  render() {
      const {form} = this.props
      const {categories, fields} = this.state
      const { getFieldDecorator } = form

        return (
            <div>
                <br />
                <h3>Add Item</h3>
                <Form>
                    <FormItem
                       label="Category">
                            {getFieldDecorator('category', {
                                rules: [{ required: true, message: 'Please select category' }],
                            })(
                                <Select onSelect={this.onSelect}>
                                    {categories && categories.map(i=>(<Option key={i.id} value={i.id}>{i.name}</Option>))}
                                </Select>
                            )}
                    </FormItem>
                    <Divider>Extra fields</Divider>
                    {fields && fields.map(i=>{
                        return (<FormItem key={i.id} label={i.name}><Input onChange={this.onItemChange(i.id)}/></FormItem>)
                    })}
                    <Divider/>
                    <FormItem
                       label="Name">
                            {getFieldDecorator('name', {
                                rules: [{ required: true, message: 'Please input the title' }],
                            })(
                                <Input />
                            )}
                    </FormItem>
                    <FormItem
                       label="Description">
                            {getFieldDecorator('description', {
                                rules: [{ required: true, message: 'Please input the description' }],
                            })(
                                <TextArea rows ={3} />
                            )}
                    </FormItem>
                    <FormItem
                       label="Price">
                            {getFieldDecorator('price', {
                                rules: [{ required: true, message: 'Please input the price' }],
                            })(
                                <Input/>
                            )}
                    </FormItem>
                    <Button type="default" onClick={this.onSubmit}>Save</Button>
                </Form>
            </div>
        );
  }
}

export default Form.create() (AddItem)
