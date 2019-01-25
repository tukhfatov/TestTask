import React, { Component } from 'react';
import {Select, Button, Form, Divider, Input, notification} from 'antd'
import 'antd/dist/antd.css';
import axios from 'axios'

const FormItem = Form.Item
const Option = Select.Option
const { TextArea } = Input;

class AddItem extends Component {

    state = {
        categories: []
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

  onSubmit = ()=>{
    const {form} = this.props
    form.validateFields((err, values) => {
        if (err) {
          return;
        }
 
        form.resetFields();
 
    });
}
  render() {
      const {form} = this.props
      const {categories} = this.state
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
                                <Select>
                                    {categories && categories.map(i=>(<Option key={i.id} value={i.id}>{i.name}</Option>))}
                                </Select>
                            )}
                    </FormItem>
                    
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
