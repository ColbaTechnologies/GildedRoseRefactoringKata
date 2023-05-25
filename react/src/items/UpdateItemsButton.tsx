import { Button } from '@chakra-ui/react'
import { useItems } from './use-items'
import React from 'react';

export const UpdateItemsButton: React.FC<{updateAction: () => void}> = ({updateAction}) => {
    return (
        <Button 
            colorScheme='teal' 
            variant='outline'
            onClick={ _ => updateAction() }
        >
            Button
        </Button>
    );
}