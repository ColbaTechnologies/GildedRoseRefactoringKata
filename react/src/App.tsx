import { ItemsTable } from './items/ItemsTable';
import { UpdateItemsButton } from './items/UpdateItemsButton';
import { useItems } from './items/use-items';
import { TableContainer, Container } from '@chakra-ui/react'

export const App = () => {
  const { current, history, updateItemsOnANewDay } = useItems();
  return (
		<Container centerContent={true} maxW='container.sm' padding={2}>
			<UpdateItemsButton updateAction={updateItemsOnANewDay} />
			<TableContainer>
				<ItemsTable items={current.items} day={current.day}/>
			</TableContainer>
		</Container>
	)
}